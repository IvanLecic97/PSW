import React, { useState, useEffect } from "react";
import Table from "react-bootstrap/Table";

function Homepage() {
  const [loadedData, setLoadedData] = useState([]);

  const loadData = async () => {
    const url = "http://localhost:56210/feedback/getAllApproved";
    try {
      const data = await fetch(url);
      const data1 = await data.json();
      console.log(data1.list);
      setLoadedData(data1.list);
    } catch (error) {
      console.log("error", error);
    }
  };

  function seePatient(e) {
    if (!e.anonymous) {
      return e.patientUsername;
    } else return "Anonymous user";
  }

  const list = (
    <div>
      <label>Feedbacks about clinic</label> <br />
      <br />
      {loadedData.map((value) => (
        <ul key={value.id}>
          <li>{value.text}</li>
          <li>Rate : {value.rating}</li>
          <li>{seePatient(value)}</li>
        </ul>
      ))}
    </div>
  );

  useEffect(() => {
    loadData();
  }, []);

  return <div>{loadedData && list}</div>;
}

export default Homepage;
