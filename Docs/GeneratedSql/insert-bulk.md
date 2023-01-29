## Bulk insert

### TPC

```postgresql
INSERT INTO "Manager" ("Id", "SuperiorId", "UserId")
VALUES (Guid_0, NULL, Guid_1);

INSERT INTO "Manager" ("Id", "SuperiorId", "UserId")
VALUES (Guid_2, NULL, Guid_3);

INSERT INTO "Manager" ("Id", "SuperiorId", "UserId")
VALUES (Guid_4, Guid_0, Guid_5);

INSERT INTO "Manager" ("Id", "SuperiorId", "UserId")
VALUES (Guid_6, Guid_2, Guid_7);

INSERT INTO "Subordinate" ("Id", "ManagerId", "UserId")
VALUES (Guid_8, Guid_2, Guid_9);

INSERT INTO "Subordinate" ("Id", "ManagerId", "UserId")
VALUES (Guid_10, Guid_2, Guid_11);

INSERT INTO "Subordinate" ("Id", "ManagerId", "UserId")
VALUES (Guid_12, Guid_0, Guid_13);

INSERT INTO "Intern" ("Id", "InternshipExpiration", "ManagerId", "UserId")
VALUES (Guid_14, DateTime, Guid_4, Guid_15);

INSERT INTO "Intern" ("Id", "InternshipExpiration", "ManagerId", "UserId")
VALUES (Guid_16, DateTime, Guid_4, Guid_17);

INSERT INTO "Subordinate" ("Id", "ManagerId", "UserId")
VALUES (Guid_18, Guid_6, Guid_19);
```

### TPH

```postgresql
INSERT INTO "Employees" ("Id", "Discriminator", "SuperiorId", "UserId")
VALUES (Guid_0, 3, NULL, Guid_1);

INSERT INTO "Employees" ("Id", "Discriminator", "InternshipExpiration", "ManagerId", "UserId")
VALUES (Guid_2, 1, DateTime, Guid_0, Guid_3);

INSERT INTO "Employees" ("Id", "Discriminator", "InternshipExpiration", "ManagerId", "UserId")
VALUES (Guid_4, 1, DateTime, Guid_0, Guid_5);

INSERT INTO "Employees" ("Id", "Discriminator", "InternshipExpiration", "ManagerId", "UserId")
VALUES (Guid_6, 1, DateTime, Guid_0, Guid_7);

INSERT INTO "Employees" ("Id", "Discriminator", "InternshipExpiration", "ManagerId", "UserId")
VALUES (Guid_8, 1, DateTime, Guid_0, Guid_9);

INSERT INTO "Employees" ("Id", "Discriminator", "InternshipExpiration", "ManagerId", "UserId")
VALUES (Guid_10, 1, DateTime, Guid_0, Guid_11);

INSERT INTO "Employees" ("Id", "Discriminator", "ManagerId", "UserId")
VALUES (Guid_12, 2, Guid_0, Guid_13);

INSERT INTO "Employees" ("Id", "Discriminator", "ManagerId", "UserId")
VALUES (Guid_14, 2, Guid_0, Guid_15);

INSERT INTO "Employees" ("Id", "Discriminator", "ManagerId", "UserId")
VALUES (Guid_16, 2, Guid_0, Guid_17);

INSERT INTO "Employees" ("Id", "Discriminator", "ManagerId", "UserId")
VALUES (Guid_18, 2, Guid_0, Guid_19);
```

### TPT

```postgresql
INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_0, Guid_1);

INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_2, Guid_3);

INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_4, Guid_5);

INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_6, Guid_7);

INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_8, Guid_9);

INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_10, Guid_11);

INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_12, Guid_13);

INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_14, Guid_15);

INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_16, Guid_17);

INSERT INTO "Employees" ("Id", "UserId")
VALUES (Guid_18, Guid_19);


INSERT INTO "Manager" ("Id", "SuperiorId")
VALUES (Guid_4, NULL);

INSERT INTO "Manager" ("Id", "SuperiorId")
VALUES (Guid_10, NULL);

INSERT INTO "Manager" ("Id", "SuperiorId")
VALUES (Guid_6, Guid_10);

INSERT INTO "Manager" ("Id", "SuperiorId")
VALUES (Guid_8, Guid_4);


INSERT INTO "Subordinate" ("Id", "ManagerId")
VALUES (Guid_12, Guid_4);

INSERT INTO "Subordinate" ("Id", "ManagerId")
VALUES (Guid_14, Guid_10);

INSERT INTO "Subordinate" ("Id", "ManagerId")
VALUES (Guid_18, Guid_10);

INSERT INTO "Subordinate" ("Id", "ManagerId")
VALUES (Guid_0, Guid_8);

INSERT INTO "Subordinate" ("Id", "ManagerId")
VALUES (Guid_2, Guid_8);

INSERT INTO "Subordinate" ("Id", "ManagerId")
VALUES (Guid_16, Guid_6);


INSERT INTO "Intern" ("Id", "InternshipExpiration")
VALUES (Guid_0, DateTime);

INSERT INTO "Intern" ("Id", "InternshipExpiration")
VALUES (Guid_2, DateTime);
```