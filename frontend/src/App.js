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
import Homepage from "./main/homepage";

function App() {
  const navigate = useNavigate();
  const [patientButton, setPatientButton] = useState(true);

  let onClickRegister = (event) => {
    event.preventDefault();
    navigate("/registerPatient");
  };

  const onClickLogout = (event) => {
    event.preventDefault();
    localStorage.clear("token");
    localStorage.clear("role");
    localStorage.clear("email");
    navigate("/homepage");
  };

  const checkPatientButton = () => {
    //event.preventDefault();
    const item = localStorage.getItem("role");
    if (item == "Patient") {
      setPatientButton(false);
    } else setPatientButton(true);
  };

  useEffect(() => {
    checkPatientButton();
  }, []);

  return (
    <React.Fragment>
      <div className="App">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
          <div className="container-fluid">
            <button
              onClick={() => {
                navigate("/homepage");
              }}
            >
              Homepage
            </button>
          </div>
          <div className="container-fluid">
            <button onClick={onClickRegister}>Register</button>
          </div>
          <div className="container-fluid">
            <button onClick={(event) => navigate("/login")}>Login</button>
          </div>
          <div className="container-fluid">
            <button onClick={(event) => onClickLogout(event)}>Logout</button>
          </div>
          <div>
            <button
              disabled={patientButton}
              onClick={() => navigate("/patientHomepage")}
            >
              Patient homepage
            </button>
          </div>
        </nav>

        <Routes>
          <Route path="/homepage" element={<Homepage />} />
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
