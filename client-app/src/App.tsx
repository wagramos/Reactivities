import React, { useState, useEffect } from 'react';
import axios from "axios";
import logo from './logo.svg';
import './App.css';

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5031/api/activities')
      .then(response => {
        setActivities(response.data)
      });
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <ul>
          {
            activities.map((item: any) => (<li key={item.id}>{item.title}</li>))
          }
        </ul>
      </header>
    </div>
  );
}

export default App;
