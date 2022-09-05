import React from "react";
import { useNavigate } from "react-router-dom";

function AdminHomepage() {
  const navigate = useNavigate();

  return (
    <div>
      <nav class="nav flex-column" style={{ width: "120px" }}>
        <button onClick={() => navigate("/allFeedbacks")}>See feedbacks</button>
      </nav>
    </div>
  );
}

export default AdminHomepage;
