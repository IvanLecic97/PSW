import "./App.css";
import "bootstrap/dist/css/bootstrap.css";
import {
  BrowserRouter,
  Routes,
  Route,
  Link,
  useNavigate,
} from "react-router-dom";
import React, { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";
import RegistrationPage from "./main/registrationPage";
import Login from "./main/login";
import PatientHomepage from "./main/patient/patientHomepage";
import AppointmentReservation from "./main/patient/appointmentReservation";
import AppointmentHistory from "./main/patient/appointmentHistory";
import DoctorHomepage from "./main/doctor/doctorHomepage";
import DoctorsAppointments from "./main/doctor/doctorsAppointments";
import SpecialistAppointments from "./main/doctor/specialistAppointments";
import ClinicFeedback from "./main/patient/clinicFeedback";
import AllFeedbacks from "./main/admin/allFeedbacks";
import AdminHomepage from "./main/admin/adminHomepage";
import SeeToxicPatients from "./main/admin/seeToxicPatients";

function App() {
  const navigate = useNavigate();
  const [loadedData, setLoadedData] = useState([]);

  let onClickRegister = (event) => {
    event.preventDefault();
    navigate("/registerPatient");
  };

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
    if (e.anonymous) {
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

  return (
    <React.Fragment>
      <div className="App">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
          <div className="container-fluid">
            <button>Homepage</button>
          </div>
          <div className="container-fluid">
            <button onClick={onClickRegister}>Register</button>
          </div>
          <div className="container-fluid">
            <button onClick={(event) => navigate("/login")}>Login</button>
          </div>
        </nav>
        {loadedData && list}
        <Routes>
          <Route path="/registerPatient" element={<RegistrationPage />} />
          <Route path="/login" element={<Login />} />
          <Route path="/patientHomepage" element={<PatientHomepage />} />

          <Route
            path="/appointmentReservation"
            element={<AppointmentReservation />}
          />
          <Route path="/appointmentHistory" element={<AppointmentHistory />} />

          <Route path="/doctorHomepage" element={<DoctorHomepage />} />
          <Route
            path="/doctorsAppointments"
            element={<DoctorsAppointments />}
          />
          <Route
            path="/specialistAppointments"
            element={<SpecialistAppointments />}
          />
          <Route path="/clinicFeedback" element={<ClinicFeedback />} />

          <Route path="/allFeedbacks" element={<AllFeedbacks />} />
          <Route path="/adminHomepage" element={<AdminHomepage />} />
          <Route path="/seeToxicPatients" element={<SeeToxicPatients />} />
        </Routes>
      </div>
    </React.Fragment>
  );
}

export default App;
