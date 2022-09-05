import axios from "axios";
import React, { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";

function AppointmentHistory() {
  const [email, setEmail] = useState(localStorage.getItem("email"));
  const [appointments, setAppoinments] = useState([]);
  const [pastAppointments, setPastAppointments] = useState([]);
  const [upcomingAppointments, setUpcomingAppointments] = useState([]);
  const [showPast, setShowPast] = useState(true);
  const [showUpcoming, setShowUpcoming] = useState(true);
  const [comment, setComment] = useState("");
  const [doctorGrade, setDoctorGrade] = useState(null);
  const token = localStorage.getItem("token");

  const loadData = async () => {
    const url = `http://localhost:56210/appointment/findUsersAppointments/${email}`;
    const data = await fetch(url, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    const data1 = await data.json();
    console.log(data1);
    setAppoinments(data1.list);
    let past = data1.list.filter((e) => e.isOver == true);
    let upcoming = data1.list.filter((e) => e.isOver == false);

    console.log(past);
    console.log(upcoming);
    setPastAppointments(past);
    setUpcomingAppointments(upcoming);
  };

  function onClickCancel(event, id) {
    event.preventDefault();
    const data = {
      Email: localStorage.getItem("email"),
      AppointmentId: id,
    };
    const url = "http://localhost:56210/appointment/cancelAppointment";
    axios
      .post(url, data, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((result) => {
        window.alert(result.data);
      });
  }

  const onChangePast = () => {
    setShowPast(!showPast);
  };

  const onChangeUpcoming = () => {
    setShowUpcoming(!showUpcoming);
  };

  const onCommentChange = (event) => {
    setComment(event.target.value);
  };
  const onGradeChange = (event) => {
    setDoctorGrade(event.target.value);
    console.log(event.target.value);
  };

  function onReviewClick(event, id) {
    const url = "http://localhost:56210/appointment/newReview";
    const data = {
      appointmentComment: comment,
      doctorGrade: doctorGrade,
      appointmentId: id,
    };
    axios
      .post(url, data, { headers: { Authorization: `Bearer ${token}` } })
      .then((res) => console.log(res.data));
  }

  const table = (
    <Table>
      <thead>
        <th>#</th>
        <th>Appointment date and time</th>
        <th>Cancel appointment</th>
        <th>Appointment comment</th>
        <th>Doctor grade</th>
        <th>Send review</th>
      </thead>
      <tbody>
        {showPast &&
          pastAppointments.map((value) => (
            <tr key={value.id}>
              <th style={{ color: "blue" }}>Past</th>
              <th>{value.date}</th>
              <th>X</th>
              <th>
                {!value.isRewieved && (
                  <textarea
                    onChange={onCommentChange}
                    placeholder="Appointment comment"
                  />
                )}
              </th>
              <th>
                {!value.isRewieved && (
                  <input
                    type="number"
                    onChange={onGradeChange}
                    placeholder="Doctor grade"
                  />
                )}
              </th>
              <th>
                {!value.isRewieved && (
                  <button onClick={(event) => onReviewClick(event, value.id)}>
                    Send
                  </button>
                )}
              </th>
            </tr>
          ))}
        {showUpcoming &&
          upcomingAppointments.map((value) => (
            <tr key={value.id}>
              <th style={{ color: "red" }}>Upcoming</th>
              <th>{value.date}</th>
              <th>
                <button onClick={(event) => onClickCancel(event, value.id)}>
                  Cancel
                </button>
              </th>
              <th>X</th>
              <th>X</th>
              <th>X</th>
            </tr>
          ))}
      </tbody>
    </Table>
  );

  useEffect(() => {
    loadData();
  }, [appointments]);

  return (
    <div>
      <div style={{ backgroundColour: "aquamarine" }}>
        <label>Don't show past appointments</label>
        <input type="checkbox" onChange={onChangePast} />
        <br />
        <label>Don't show upcoming appointments</label>
        <input type="checkbox" onChange={onChangeUpcoming} />
      </div>
      {appointments && table}
    </div>
  );
}

export default AppointmentHistory;
