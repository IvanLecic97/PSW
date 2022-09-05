import axios from "axios";
import React, { useState, useEffect } from "react";
import { Form, FormGroup } from "react-bootstrap";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const AppointmentReservation = () => {
  const [doctorName, setDoctorName] = useState(" ");
  const [dateLower, setDateLower] = useState(new Date());
  const [dateUpper, setDateUpper] = useState(new Date());
  const [prioritiseDoctor, setPrioritiseDoctor] = useState(false);
  const [prioritiseDate, setPrioritiseDate] = useState(false);
  const [loadedAppointmentsList, setLoadedAppointemtsList] = useState([]);
  const displayAppointment = [];

  let onSubmit = (event) => {
    event.preventDefault();
    let priority = "";
    if (prioritiseDoctor == true) {
      priority = "doctor";
    } else if (prioritiseDate == true) {
      priority = "time";
    }
    const data = {
      DoctorName: doctorName,
      DateLower: dateLower,
      DateUpper: dateUpper,
      Priority: priority,
    };
    const url = "http://localhost:56210/appointment/findByPriority";
    axios
      .post(url, data, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
      })
      .then((response) => {
        console.log(response.data);
        setLoadedAppointemtsList(response.data.list);
      });
    console.log(priority);
  };

  const displayAppointments = async () => {
    {
      for (let item of loadedAppointmentsList) {
        displayAppointment.push(item);
      }
    }
  };

  function dateParser(date) {
    let d1 = date.toString();
    return new Date(d1);
  }

  function onClickAppointment(id) {
    const data = {
      appointmentId: id,
      patientUsername: localStorage.getItem("email"),
    };

    axios.post("http://localhost:56210/appointment/makeReservation", data, {
      headers: {
        Authorization: `Bearer ${localStorage.getItem("token")}`,
      },
    });
  }

  useEffect(() => {
    displayAppointments();
  }, [loadedAppointmentsList]);

  return (
    <div>
      <Form style={{ width: "350px" }} onSubmit={onSubmit}>
        <FormGroup>
          <input
            type="text"
            onChange={(event) => setDoctorName(event.target.value)}
            placeholder="Doctor name"
            name="doctorName"
          ></input>
        </FormGroup>
        <FormGroup>
          <DatePicker
            selected={dateLower}
            onChange={(date) => setDateLower(date)}
            dateFormat="yyyy/MM/dd"
          />
        </FormGroup>
        <FormGroup>
          <DatePicker
            selected={dateUpper}
            onChange={(date) => setDateUpper(date)}
            dateFormat="yyyy/MM/dd"
          />
        </FormGroup>

        <FormGroup>
          <div class="form-check">
            <input
              class="form-check-input"
              type="checkbox"
              value=""
              id="doctor"
              onChange={(event) => setPrioritiseDoctor(event.target.checked)}
            />
            <label class="form-check-label" for="doctor">
              Prioritise doctor
            </label>
          </div>
        </FormGroup>

        <FormGroup>
          <div class="form-check">
            <input
              class="form-check-input"
              type="checkbox"
              value=""
              id="date"
              onChange={(event) => setPrioritiseDate(event.target.checked)}
            />
            <label class="form-check-label" for="date">
              Prioritise date
            </label>
          </div>
        </FormGroup>

        <FormGroup>
          <button type="submit">Filter</button>
        </FormGroup>
      </Form>

      <div>
        {loadedAppointmentsList &&
          loadedAppointmentsList.map((item) => (
            <li key={item.id}>
              {" "}
              {item.date}{" "}
              <button type="button" onClick={onClickAppointment(item.id)}>
                Make!
              </button>
            </li>
          ))}
      </div>
    </div>
  );
};

export default AppointmentReservation;
