import './App.css';
import { useEffect, useState, React } from 'react';

function App() {
  const [bugs, setBugs] = useState([])
  const [users, setUsers] = useState([])
  const [newBugTitle, setNewBugTitle] = useState("")
  const [newBugDescription, setNewBugDescription] = useState("")
  const [newUserName, setNewUserName] = useState("")
  const [assignUserName, setAssignUserName] = useState("")


  const bugUrl = `http://localhost:80/Bug`  
  const userUrl = `http://localhost:80/User`


  async function getBugs() {
    const response = await fetch(bugUrl).then(r => r.json())
    return response
  }

  async function getUsers() {
    const response = await fetch(userUrl).then(r => r.json())
    return response
  }

  async function handleCreateBug(e) {
    e.preventDefault()
    await fetch(
      bugUrl,
      {
        method: "post",
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify({title: newBugTitle, description: newBugDescription})
      })
  }

  async function handleCreateUser(e) {
    e.preventDefault()
    await fetch(
      userUrl,
      {
        method: "post",
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify({name: newUserName})
      })
  }

  async function handleAssignUser(e, bugId) {
    e.preventDefault()
    const userId = users.find(u => u.name === assignUserName).id
    console.log("user id:" + userId)
    console.log("user name:" + assignUserName)

    const response = await fetch(
      `${bugUrl}/${bugId}/assignuser`,
      {
        method: "patch",
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify({userId: userId})
      })

      console.log(response)
  }


  async function handleCloseBug(e, id)
  {
    e.preventDefault()
    await fetch(
      `${bugUrl}/${id}/close`,
      {
        method: "patch",
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify({title: newBugTitle, description: newBugDescription})
      })
  }


  useEffect(() => {
    getBugs().then(setBugs);
    getUsers().then(setUsers);
  });


  return (
    <div className="App">
      <header className="App-header">
        <h1>BugTracker</h1>
      </header>

      <div>
        <h2>Create Bug</h2>
        <form onSubmit={handleCreateBug}>
          <label htmlFor="title">Title:</label>
          <input type="text" id="title" onChange={(e) =>setNewBugTitle(e.target.value)} />
          <label htmlFor="description">Description:</label>
          <textarea type="text" id="description" onChange={(e) =>setNewBugDescription(e.target.value)}/>
          <input type="submit"  value="Submit" />
        </form>
      </div>

      <div>
      <h2>Open Bugs</h2>
          { bugs.filter(b => b.isOpen).map(b => 
          <div key={b.id}>
            <b>{b.title} </b>
            <br/> Created At: {b.dateCreated}
            <br/> {b.description}
            <br/> <i>Assignees:</i> {b.users ? b.users.map(u => u.name) : "None"}
            <br/>
            <form onSubmit={(e) => handleAssignUser(e, b.id)}>
              <label htmlFor="assignuser">Assign User:</label> 
              <input type="text" id="assignuser" onChange={(e) => setAssignUserName(e.target.value)}></input>
            </form>

            <br/> <button onClick={(e) => handleCloseBug(e, b.id)}>Close</button>
          </div>
            )}
      </div>

      <div>
      <h2>Closed Bugs</h2>
          { bugs.filter(b => !b.isOpen).map(b => 
          <div key={b.id}>
            <b>{b.title} </b>
            <br/> {b.description}
            <br/> <i>Assignees:</i> {b.users ? b.users : "None"}
          </div>
            )}
      </div>

      <div>
      <h2>Users</h2>
          { users.map(u => 
          <div key={u.id}>
            <b>{u.name} </b>
          </div>
            )}
      </div>

      <div>
        <h2>Create User</h2>
        <form onSubmit={handleCreateUser}>
          <label htmlfor="name">Name:</label>
          <input type="text" id="name" onChange={(e) => setNewUserName(e.target.value)}/> 
        </form>
      </div>

    </div>
  );
}

export default App;
