
# VUTTR.Api

This project is my solution to the [BossaBox backend challenge](https://bossabox.notion.site/Back-end-0b2c45f1a00e4a849eefe3b1d57f23c6)

## Technologies and libraries used

- C#
- ASP.NET Core Web API
- Minimal API
- Entity Framework Core
- Microsoft Identity
- Microsoft AspNetCore Authentication JwtBearer
- Carter
- Fluent Validation
- Fluent Assertions
- XUnit
- Bogus
- Swagger
- PostgreSQL
- Docker

## API documentation

#### Create a tool

```
  POST /tools
```

#### Get all tools or a tool with a common tag

```
  GET /tools?tag=example
```

#### Delete a tool by id

```
  DELETE /tools/{id:guid}
```