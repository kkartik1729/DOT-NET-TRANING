# 04Aug2026_Ass

ASP.NET Core 8 Web API for Student and Course management, using
Entity Framework Core (Code First) with SQL Server and migrations,
plus a Repository-interface / Service-implementation pattern.

Rebuilt to match:
https://github.com/divyansh653/dot-net-practical/tree/main/Assignments/4_Augest

## Entities

**Student**: Id, Name (required, 3–25 chars), Age (required, 18–25), Email (required, valid email)

**Course**: CourseId, CourseName (required, max 50 chars), StudentName (required, max 30 chars)

*(Course stores `StudentName` as a plain string rather than a foreign key
to Student — this matches the structure of the original source repo,
which does not model a relationship between the two entities.)*

## Setup & Run

```bash
dotnet restore

# Update the connection string in appsettings.json first if needed
dotnet ef database update

dotnet run
```

Swagger UI opens automatically at `/swagger`.

## Endpoints

| Entity  | GET (all)      | GET (by id)         | POST           | PUT                 | DELETE              |
|---------|-----------------|-----------------------|-----------------|-----------------------|-----------------------|
| Student | `/api/Students`| `/api/Students/{id}` | `/api/Students`| `/api/Students/{id}` | `/api/Students/{id}` |
| Course  | `/api/Courses` | `/api/Courses/{id}`  | `/api/Courses` | `/api/Courses/{id}`  | `/api/Courses/{id}`  |

## Migrations included

- `InitialCreate` — creates the `Students` table
- `AddCourseTable` — creates the `Courses` table

If you need to regenerate migrations from scratch instead of using the
ones included here, delete the `Migrations` folder and run:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
