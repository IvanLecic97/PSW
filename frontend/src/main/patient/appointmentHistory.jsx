import axios from "axios";
import React, { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";

function AppointmentHistory() {
  const [email, setEmail] = useState(localStorage.getItem("email"));
  const [appointments, setAppoinments] = useState([]);

  const loadData = async () => {
    const url = `http://localhost:56210/appointment/findUsersAppointments/${email}`;
    const data = await fetch(url);
    const data1 = await data.json();
    console.log(data1);
    setAppoinments(data1.list);
  };

  function onClickCancel(event, id) {
    event.preventDefault();
    const data = {
      Email: localStorage.getItem("email"),
      AppointmentId: id,
    };
    const url = "http://localhost:56210/appointment/cancelAppointment";
    axios.post(url, data).then((result) => {
      window.alert(result.data);
    });
  }

  const table = (
    <Table>
      <thead>
        <th>#</th>
        <th>Appointment date and time</th>
        <th>Cancel appointment</th>
      </thead>
      <tbody>
        {appointments.map((value) => (
          <tr key={value.id}>
            <th>#</th>
            <th>{value.date}</th>
            <th>
              <button onClick={(event) => onClickCancel(event, value.id)}>
                Cancel
              </button>
            </th>
          </tr>
        ))}
      </tbody>
    </Table>
  );

  useEffect(() => {
    loadData();
  }, []);

  return <div>{appointments && table}</div>;
}

export default AppointmentHistory;
