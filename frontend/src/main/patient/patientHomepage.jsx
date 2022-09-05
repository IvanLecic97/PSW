import React from "react";

import { useNavigate } from "react-router-dom";

const PatientHomepage = () => {
  const navigate = useNavigate();
  return (
    <div>
      <nav class="nav flex-column" style={{ width: "120px" }}>
        <button onClick={(event) => navigate("/appointmentReservation")}>
          Appointment reservation
        </button>
        <button onClick={() => navigate("/appointmentHistory")}>
          Appointment history
        </button>
        <button onClick={() => navigate("/clinicFeedback")}>
          Clinic feedback
        </button>
      </nav>
    </div>
  );
};

export default PatientHomepage;
