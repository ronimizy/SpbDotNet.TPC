## Single type query

### TPC

```postgresql
SELECT m."Id",
       m."UserId",
       m."SuperiorId",
       'Manager' AS "Discriminator"
FROM "Manager" AS m
```

### TPH

```postgresql
SELECT e."Id", e."Discriminator", e."UserId", e."SuperiorId"
FROM "Employees" AS e
WHERE e."Discriminator" = 8
```

### TPT

```postgresql
SELECT e."Id",
       e."UserId",
       m."SuperiorId",
       CASE
           WHEN m."Id" IS NOT NULL THEN 'Manager'
           END AS "Discriminator"

FROM "Employees" AS e
         LEFT JOIN "Manager" AS m ON e."Id" = m."Id"
WHERE m."Id" IS NOT NULL
```