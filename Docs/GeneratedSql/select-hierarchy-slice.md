## Hierarchy slice query

### TPC

```postgresql
SELECT s."Id",
       s."UserId",
       s."ManagerId",
       NULL          AS "InternshipExpiration",
       'Subordinate' AS "Discriminator"
FROM "Subordinate" AS s

UNION ALL
SELECT i."Id",
       i."UserId",
       i."ManagerId",
       i."InternshipExpiration",
       'Intern' AS "Discriminator"
FROM "Intern" AS i
```

### TPH

```postgresql
SELECT e."Id",
       e."Discriminator",
       e."UserId",
       e."ManagerId",
       e."InternshipExpiration"

FROM "Employees" AS e
WHERE e."Discriminator" IN (4, 2)
```

### TPT

```postgresql
SELECT e."Id",
       e."UserId",
       s."ManagerId",
       i."InternshipExpiration",
       CASE
           WHEN i."Id" IS NOT NULL THEN 'Intern'
           WHEN s."Id" IS NOT NULL THEN 'Subordinate'
           END AS "Discriminator"

FROM "Employees" AS e
         LEFT JOIN "Subordinate" AS s ON e."Id" = s."Id"
         LEFT JOIN "Intern" AS i ON e."Id" = i."Id"

WHERE (i."Id" IS NOT NULL)
   OR (s."Id" IS NOT NULL)
```