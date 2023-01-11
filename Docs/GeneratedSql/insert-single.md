## Single insert

### TPC

```postgresql
INSERT INTO "Subordinate" ("Id", "ManagerId", "UserId")
VALUES (Guid_1, NULL, Guid_2);
```

### TPH

```postgresql
INSERT INTO "Employees" ("Id", "Discriminator", "ManagerId", "UserId")
VALUES (Guid_1, 4, NULL, Guid_2);
```

### TPT

```postgresql
INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_1, Guid_2);

INSERT INTO "Subordinate" ("Id", "ManagerId")
VALUES (Guid_1, NULL);
```
