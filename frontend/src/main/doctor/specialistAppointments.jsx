import React, { useState, useEffect } from "react";
import axios from "axios";
import Table from "react-bootstrap/Table";

function SpecialistAppointments() {
  const token = localStorage.getItem("token");
  const email = localStorage.getItem("email");
  const appId = localStorage.getItem("appointmentId");
  const [loadedData, setData] = useState([]);
  const [text, setText] = useState("");

  const loadData = async () => {
    const url = "http://localhost:56210/appointment/getSpecialistAppointments";

    try {
      const data = await fetch(url, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      const data1 = await data.json();

      console.log(data1);
      setData(data1.list);
    } catch (error) {
      console.log("error", error);
    }
  };

  const onChangeText = (event) => {
    setText(event.target.value);
  };

  function writeReferral(event, entity) {
    event.preventDefault();
    const url = "http://localhost:56210/appointment/newReferral";
    const data = {
      text: text,
      familyDoctorEmail: email,
      specialistId: entity.doctorId,
      patientId: localStorage.getItem("patientId"),
      date: entity.date,
      appointmentId: entity.id,
      familyDoctorAppointmentId: appId,
    };
    axios
      .post(url, data, { headers: { Authorization: `Bearer ${token}` } })
      .then((res) => window.alert(res.data.list));
  }

  useEffect(() => {
    console.log(localStorage.getItem("patientId"));
    loadData();
  }, []);

  return (
    <div style={{ backgroundColor: "aquamarine" }}>
      {loadedData && (
        <Table>
          <thead>
            <th>#</th>
            <th>Date and time</th>
            <th>Doctor name</th>
            <th>Doctor surname</th>
            <th>Referral</th>
            <th>Send</th>
          </thead>
          <tbody>
            {loadedData.map((value) => (
              <tr key={value.appointment.id}>
                <th></th>
                <th>{value.appointment.date}</th>
                <th>{value.name}</th>
                <th>{value.surname}</th>
                <th>
                  <textarea
                    placeholder="Write perscription"
                    onChange={onChangeText}
                  />
                </th>
                <th>
                  <button
                    onClick={(event) => writeReferral(event, value.appointment)}
                  >
                    Send
                  </button>
                </th>
              </tr>
            ))}
          </tbody>
        </Table>
      )}
    </div>
  );
}

export default SpecialistAppointments;
