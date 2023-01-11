## Query one-to-many relation

### TPC

```postgresql
SELECT t."Id",
       t."Name",
       t."ParentId",
       t."ProjectId",
       t."Description",
       t."EndDate",
       t."ExecutorId",
       t."StartDate",
       t."Discriminator"

FROM (SELECT p0."Id",
             p0."Name",
             p0."ParentId",
             p0."ProjectId",
             NULL           AS "Description",
             NULL           AS "EndDate",
             NULL           AS "ExecutorId",
             NULL           AS "StartDate",
             'ProjectStage' AS "Discriminator"
      FROM "ProjectStage" AS p0
      
      UNION ALL
      SELECT p1."Id",
             p1."Name",
             p1."ParentId",
             p1."ProjectId",
             p1."Description",
             p1."EndDate",
             p1."ExecutorId",
             p1."StartDate",
             'ProjectTask' AS "Discriminator"
      FROM "ProjectTask" AS p1) AS t
         INNER JOIN "Projects" AS p ON t."ProjectId" = p."Id"
WHERE p."Id" = ProjectId
```

### TPH

```postgresql
SELECT p."Id", p."Discriminator", p."Name", p."ParentId", p."ProjectId", p."Description", p."EndDate", p."ExecutorId", p."StartDate"
FROM "ProjectItems" AS p
INNER JOIN "Projects" AS p0 ON p."ProjectId" = p0."Id"
WHERE p0."Id" = ProjectId
```

### TPT

```postgresql
SELECT p."Id",
       p."Name",
       p."ParentId",
       p."ProjectId",
       p1."Description",
       p1."EndDate",
       p1."ExecutorId",
       p1."StartDate",
       CASE
           WHEN p1."Id" IS NOT NULL THEN 'ProjectTask'
           WHEN p0."Id" IS NOT NULL THEN 'ProjectStage'
           END AS "Discriminator"
FROM "ProjectItems" AS p
         LEFT JOIN "ProjectStage" AS p0 ON p."Id" = p0."Id"
         LEFT JOIN "ProjectTask" AS p1 ON p."Id" = p1."Id"
         INNER JOIN "Projects" AS p2 ON p."ProjectId" = p2."Id"
WHERE p2."Id" = ProjectId
```