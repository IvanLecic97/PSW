import React, { useState, useEffect } from "react";
import axios from "axios";
import Table from "react-bootstrap/Table";

function SeeToxicPatients() {
  const token = localStorage.getItem("token");
  const [loadedData, setLoadedData] = useState([]);
  const [toxicPatients, setToxicPatients] = useState([]);
  const [blockedPatients, setBlockedPatients] = useState([]);

  const loadData = async () => {
    const url = "http://localhost:56210/patients/allToxic";
    try {
      const data = await fetch(url, {
        headers: { Authorization: `Bearer ${token}` },
      });
      const data1 = await data.json();
      console.log(data1);
      setLoadedData(data1.list);
      let blocked = data1.list.filter((e) => e.isBlocked == true);
      let toxic = data1.list.filter((e) => e.isBlockable == true);

      setBlockedPatients(blocked);
      setToxicPatients(toxic);

      console.log(toxic);
    } catch (error) {
      console.log("error", error);
    }
  };

  function blockPatient(event, email) {
    event.preventDefault();
    const url = "http://localhost:56210/patients/block";
    const data = {
      email: email,
    };
    axios
      .post(url, data, { headers: { Authorization: `Bearer ${token}` } })
      .then((res) => {
        window.alert(res.data.response);
        window.location.reload(false);
      });
  }

  function unBlockPatient(event, email) {
    event.preventDefault();
    const url = "http://localhost:56210/patients/unblock";
    const data = {
      email: email,
    };
    axios
      .post(url, data, { headers: { Authorization: `Bearer ${token}` } })
      .then((res) => {
        window.alert(res.data.response);
        window.location.reload(false);
      });
  }

  function removeFromToxic(event, email) {
    event.preventDefault();
    const url = "http://localhost:56210/patients/removeFromToxic";
    const data = {
      email: email,
    };
    axios
      .post(url, data, { headers: { Authorization: `Bearer ${token}` } })
      .then((res) => {
        window.alert(res.data.response);
        window.location.reload(false);
      });
  }

  const table = (
    <Table>
      <thead>
        <th>#</th>
        <th>Patient name</th>
        <th>Patient surname</th>
        <th>Patient phone number</th>
        <th>Remove from toxic list</th>
        <th>Block patient</th>
        <th>Unblock patient</th>
      </thead>
      <tbody>
        {blockedPatients &&
          blockedPatients.map((value) => (
            <tr key={value.id}>
              <th style={{ color: "black" }}>BLOCKED</th>
              <th>{value.name}</th>
              <th>{value.surname}</th>
              <th>{value.phone}</th>
              <th>X</th>
              <th>X</th>
              <th>
                <button onClick={(event) => unBlockPatient(event, value.email)}>
                  Unblock
                </button>
              </th>
            </tr>
          ))}
        {toxicPatients &&
          toxicPatients.map((value) => (
            <tr key={value.id}>
              <th style={{ color: "green" }}>TOXIC</th>
              <th>{value.name}</th>
              <th>{value.surname}</th>
              <th>{value.phone}</th>
              <th>
                <button
                  onClick={(event) => removeFromToxic(event, value.email)}
                >
                  Remove
                </button>
              </th>
              <th>
                <button onClick={(event) => blockPatient(event, value.email)}>
                  Block
                </button>
              </th>
              <th>X</th>
            </tr>
          ))}
      </tbody>
    </Table>
  );

  useEffect(() => {
    loadData();
  }, []);

  return <div>{table}</div>;
}

export default SeeToxicPatients;
