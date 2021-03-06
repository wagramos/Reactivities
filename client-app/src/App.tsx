import React, { useState, useEffect } from 'react';
import axios from "axios";
//import logo from './logo.svg';
import './App.css';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5031/api/activities')
      .then(response => {
        setActivities(response.data)
      });
  }, []);

  return (
    <div>
      <Header as='h2' icon='users' content="Reactivities" />
      <List>
        {
          activities.map((item: any) => (<List.Item key={item.id}>{item.title}</List.Item>))
        }
      </List>

    </div>
  );
}

export default App;
