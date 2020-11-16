# MachineStream

## Create the database

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Endpoint

### GET /machine-info?status=running

Response:

```json
{
  "items": [
    {
      "machineInfoId": 1,
      "machine_id": "840c6335-c0b9-49f8-9eba-e52ef9e23c43",
      "id": "c7a057ce-544a-47d2-bf98-39b488f9a76a",
      "timestamp": "2020-11-16T06:39:47.068509",
      "status": "running"
    },
    {
      "machineInfoId": 2,
      "machine_id": "63f9d31e-18cf-4def-8887-164366d70c46",
      "id": "bf3a3aaf-3ee7-4876-bee0-30cb6817111a",
      "timestamp": "2020-11-16T06:39:52.080248",
      "status": "running"
    }
  ]
}
```

### TODO's

- Add unit-tests
- POST Endpoint for starting stoping the Hosted Worker Service
- Adjust get endpoints to the specs of the front-end team
- Replace with a real-database, currently sqlite
- Error/Exception/Timeout handling
- Security (ipFilter, cors)
- Test the dockerfile
- Monitor the system perfomance when running as hosted service

### Problems encountered

- Running a worker as a hosted service, i used the `dotnet new worker` template as a starting point.
  But integrated it later into the Web API itself.
- No Singleton in HostedServices only Scoped
- Use the count property from websocket to receive the correct size of the byte array (deserialization errors, not valid json)
- EntityFrame FOREIGN KEY Constrain with MachineInfo.Id
