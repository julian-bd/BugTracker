# BugTracker

## About

BugTracker is a simple bug tracking app.  
The frontend is a SPA written in React, while the backend is a dotnet API using Mongo for data persistence.  
Currently, the front end allows for the creation and viewing of bugs and users, and also the ability to close bugs. It does not yet fully utilise the existing abilities of the API, which would additionally allow for users to be assigned to Bugs, and for user names to be changed.


## Development
### Requirements
- Node
- Dotnet SDK

### Building

#### Backend
Navigate to the `Server` directory in a terminal, and run the command `dotnet build`

#### Frontend
Navigate to the `App` directory in a terminal, and run the command `npm run build`

### Testing

The backend includes a number of unit tests that can be run via an IDE, or via the command line by navigating to the `Server` directory, and running the command `dotnet test`.

## Running

### Requirements
- Docker
- Node

### Backend
The backend can be run via Docker. Open a terminal in this directory, then:
```bash
$ cd Server
$ docker build -t bugtracker-server -f Dockerfile .
$ cd ..
$ docker-compose up -d
```

### Frontend
From here, you can start the front end by navigating to the App directory, running it via npm:

```bash
$ cd App
$ npm start
```
