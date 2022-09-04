import React from "react";
import { useNavigate } from "react-router-dom";

function DoctorHomepage() {
  const navigate = useNavigate();
  return (
    <div>
      <nav class="nav flex-column" style={{ width: "120px" }}>
        <button onClick={() => navigate("/doctorsAppointments")}>
          See appointments
        </button>
      </nav>
    </div>
  );
}

export default DoctorHomepage;
