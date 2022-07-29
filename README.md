# What this is

This is a web app I'm currently developing to improve my skills with MVC and .NET in general.

With Find-A-Band, musicians can find ads for bands currently looking for new members.

# Steps taken (so far)

### This is a work in progress! ###
Updates will be put here as development takes its course.

Front-end design is not a concern right now, so everything still looks a little clumsy.

### 1. Models created
Models were made for *users*, *bands*, *addresses* and *ads*. Also, enums for *ad categories* and *band genres* were created.

### 2. DbContext configured
DbContext configurations were done, migrations were successfully made and server is ready to go. Used Docker and SQL Server.

### 3. Controllers and Views added
Controllers for *bands* and *ads* were made, as well as the Views for these pages. Data was seeded to test the Views.

### 4. Repositories created
Repositories for *bands* and *ads* were made, later refactored into Controllers and injected into Program file.

### 5. Create methods added
Methods to create new *bands* and *ads* are now functional.

### 6. Photo upload added
Used Cloudinary to enable photo upload while creating new *bands* and *ads*. Settings were stored with user-secrets. Still needs to config image sizes and crops.

### 7. Edit and Delete methods added
We can now edit and delete *bands* and *ads*.

# Tools used

- Visual Studio 2022, as IDE
- Entity Framework, for migrations
- Docker, to set up connection with SQL Server
- Cloudinary, to enable image upload
