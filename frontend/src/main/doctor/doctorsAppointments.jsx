import React, { useState, useEffect } from "react";
import axios from "axios";
import Table from "react-bootstrap/Table";

function DoctorsAppointments() {
  const token = localStorage.getItem("token");
  const email = localStorage.getItem("email");
  const [loadedData, setData] = useState([]);

  const loadData = async () => {
    const url = `http://localhost:56210/appointment/getDoctorsAppointments/${email}`;

    try {
      const data = await fetch(url, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      const data1 = await data.json();
      console.log(data1.list);
      setData(data1.list);
    } catch (error) {
      console.log(error, "error");
    }
  };

  function onReferralClick(event, id, appointmentId) {
    //event.preventDefault();
    localStorage.setItem("patientId", id);
    localStorage.setItem("appointmentId", appointmentId);
    window.open("/specialistAppointments");
  }

  useEffect(() => {
    loadData();
  }, []);

  return (
    <div style={{ backgroundColor: "aquamarine" }}>
      {loadedData && (
        <Table>
          <thead>
            <th>#</th>
            <th>Date and time </th>
            <th>Give referral</th>
          </thead>
          <tbody>
            {loadedData.map((value) => (
              <tr key={value.id}>
                <th>#</th>
                <th>{value.date}</th>
                <th>
                  <button
                    onClick={(event) =>
                      onReferralClick(event, value.patientId, value.id)
                    }
                  >
                    Referral
                  </button>
                </th>
                <th>
                  <textarea placeholder="Write referral" />
                </th>
              </tr>
            ))}
          </tbody>
        </Table>
      )}
    </div>
  );
}

export default DoctorsAppointments;
