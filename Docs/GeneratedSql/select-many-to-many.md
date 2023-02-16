## Query many-to-many relation

### TPC

```postgresql
SELECT t0."Id", t0."ManagerId", t0."UserId", t0."InternshipExpiration", t0."Discriminator"
FROM "Projects" AS p
         INNER JOIN
     (SELECT t."Id", t."ManagerId", t."UserId", t."InternshipExpiration", t."Discriminator", p0."ProjectsId"
      FROM "ProjectClients" AS p0
               INNER JOIN
           (SELECT m."Id",
                   m."ManagerId",
                   m."UserId",
                   NULL::timestamptz AS "InternshipExpiration",
                   'Manager'         AS "Discriminator"
            FROM "Manager" AS m

            UNION ALL
            SELECT s."Id", s."ManagerId", s."UserId", NULL AS "InternshipExpiration", 'Subordinate' AS "Discriminator"
            FROM "Subordinate" AS s

            UNION ALL
            SELECT i."Id", i."ManagerId", i."UserId", i."InternshipExpiration", 'Intern' AS "Discriminator"
            FROM "Intern" AS i) AS t
           ON p0."ClientsId" = t."Id") AS t0
     ON p."Id" = t0."ProjectsId"
WHERE p."Id" = ProjectId
```

### TPH

```postgresql
SELECT t."Id", t."Discriminator", t."ManagerId", t."UserId", t."InternshipExpiration"
FROM "Projects" AS p
         INNER JOIN
     (SELECT e."Id", e."Discriminator", e."ManagerId", e."UserId", e."InternshipExpiration", p0."ProjectsId"
      FROM "ProjectClients" AS p0
               INNER JOIN "Employees" AS e ON p0."ClientsId" = e."Id") AS t
     ON p."Id" = t."ProjectsId"
WHERE p."Id" = ProjectId
```

### TPT

```postgresql
SELECT t0."Id", t0."ManagerId", t0."UserId", t0."InternshipExpiration", t0."Discriminator"
FROM "Projects" AS p
         INNER JOIN
     (SELECT t."Id", t."ManagerId", t."UserId", t."InternshipExpiration", t."Discriminator", p0."ProjectsId"
      FROM "ProjectClients" AS p0
               INNER JOIN
           (SELECT e."Id",
                   e."ManagerId",
                   e."UserId",
                   i."InternshipExpiration",
                   CASE
                       WHEN i."Id" IS NOT NULL THEN 'Intern'
                       WHEN s."Id" IS NOT NULL THEN 'Subordinate'
                       WHEN m."Id" IS NOT NULL THEN 'Manager'
                       END AS "Discriminator"
            FROM "Employees" AS e
                     LEFT JOIN "Manager" AS m ON e."Id" = m."Id"
                     LEFT JOIN "Subordinate" AS s ON e."Id" = s."Id"
                     LEFT JOIN "Intern" AS i ON e."Id" = i."Id") AS t
           ON p0."ClientsId" = t."Id") AS t0
     ON p."Id" = t0."ProjectsId"
WHERE p."Id" = ProjectId
```