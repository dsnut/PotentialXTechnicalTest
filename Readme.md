# PotentialX technical test

# Summary of the code
- There are 3 components in the solution a Restful API, an MVC Web application and a postman/curl script.
- API(PotentialXTestAPI) provides a restful endpoint to read person, events data and to write new events 
- For sake of simplicity data stores are just json files person.json and events.json inside the API.
- MVC web application(PotentialXTestWeb) talks to the API to get the person/event data 
- Run the API and the Web application together, may need to change the appsettings.json if the API/App runs on a different port on your machine.
- Postman script is there to add an event at runtime 
- SignalR is used to refresh the page as soon an event is added in the event datastore(events.json)
- Use VS 2019 to run.


# Assumptions
- Assumed basic data for person and event, would have been good to have sample data as part of the exercise.
- Filtering of events for a person is done on firstname, lastname and dob.
- Datastore can be anything, for this exercise I have used json files.

# Question
1.	If you had more time, what would you change or focus more time on?
  - Get the code production ready by adding logging, exception handling, authentication layer for API, more unit testing.
  - Deployment using code as infrastructure.
  - User interface to be prettyfied.

2.	Which part of the solution consumed the most amount of time?
  - Use case analysis and solution design.
  - Had to dig in a bit to get SignalR working.
  
3.	What would you suggest to the clinicians that they may not have thought of in regard to their request?
  - Because person and events are separate data stores and reconciliation is only based on name and dob, I would suggest clinicians that there might be a risk of data not being 100% correct in some cases.
  

