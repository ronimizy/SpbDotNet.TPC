## All hierarchy query

### TPC

```postgresql
SELECT m."Id",
       m."UserId",
       m."SuperiorId",
       NULL::uuid        AS "ManagerId",
       NULL::timestamptz AS "InternshipExpiration",
       'Manager'         AS "Discriminator"
FROM "Manager" AS m

UNION ALL
SELECT s."Id",
       s."UserId",
       NULL          AS "SuperiorId",
       s."ManagerId",
       NULL          AS "InternshipExpiration",
       'Subordinate' AS "Discriminator"
FROM "Subordinate" AS s

UNION ALL
SELECT i."Id",
       i."UserId",
       NULL     AS "SuperiorId",
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
       e."SuperiorId",
       e."ManagerId",
       e."InternshipExpiration"
FROM "Employees" AS e
```

### TPT

```postgresql
SELECT e."Id",
       e."UserId",
       m."SuperiorId",
       s."ManagerId",
       i."InternshipExpiration",
       CASE
           WHEN i."Id" IS NOT NULL THEN 'Intern'
           WHEN s."Id" IS NOT NULL THEN 'Subordinate'
           WHEN m."Id" IS NOT NULL THEN 'Manager'
           END AS "Discriminator"

FROM "Employees" AS e
         LEFT JOIN "Manager" AS m ON e."Id" = m."Id"
         LEFT JOIN "Subordinate" AS s ON e."Id" = s."Id"
         LEFT JOIN "Intern" AS i ON e."Id" = i."Id"
```