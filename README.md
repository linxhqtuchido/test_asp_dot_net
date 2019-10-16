# PLEASE NOT OPEN PROJECT ON VISUAL STUDIO

### Requirements

- Install dotnet commandline.

Link : https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/install?initial-os=windows

- Install MySQL.

### Import database

Create new a database, then import file `member_member.sql`

### Config database

Open file `appsettings.json`

Then update here

`...`


`
"ConnectionStrings":{
  "DefaultConnection": "server=localhost;port=3306;database=member;user=root;password=root"
}
`

`...`

### Run project

`dotnet run watch` then open link `https://localhost:5001`
