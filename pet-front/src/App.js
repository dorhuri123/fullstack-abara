import React, { useState } from "react";
import "./App.css";
import Spinner from "react-bootstrap/Spinner";
import axios from "axios";
function App() {
  const [name, setName] = useState("");
  const [age, setAge] = useState("");
  const [color, setColor] = useState("#563d7c");
  const [type, setType] = useState("Dog");
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");
  const [spinnerOn, setSpinnerOn] = useState(false);
  const [newPet, setNewPet] = useState({
    Name: "",
    Age: "",
    Type: "",
    Created_at: "",
  });
  const handleSubmit = async (e) => {
    setNewPet({ Name: name, Created_at: Date(), Age: age, Type: type });
    e.preventDefault();
    setSpinnerOn(true);
    try {
      await axios.post("http://localhost:5000/api/pet", newPet);
      setSuccess("pet successfully uploaded");
      setError("");
    } catch (err) {
      setError("Error creating new pet.");
      setSuccess("");
    }
    setSpinnerOn(false);
  };
  return (
    <div className="petForm">
      {spinnerOn && <Spinner animation="border" className="center" />}
      <h1>Add new pet</h1>
      {error && <p className="error">{error}</p>}
      {success && <p className="success">{success}</p>}
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Name</label>
          <input
            type="text"
            className="form-control"
            maxLength={25}
            value={name}
            onChange={(e) => setName(e.target.value)}
            id="exampleFormControlInput1"
          />
        </div>
        <label className="form-label">Pet Color</label>
        <input
          type="color"
          className="form-control form-control-color"
          id="exampleColorInput"
          value={color}
          onChange={(e) => setColor(e.target.value)}
          title="Choose your color"
        />
        <label>Age</label>
        <input
          type="text"
          className="form-control"
          value={age}
          onChange={(e) => {
            if (e.target.value > 20) setAge(20);
            else setAge(e.target.value);
          }}
          id="exampleFormControlInput1"
        />
        <div className="form-group">
          <label>Type</label>
          <select
            className="form-control"
            id="exampleFormControlSelect1"
            onChange={(e) => setType(e.target.value)}
            value={type}
          >
            <option>Dog</option>
            <option>Cat</option>
            <option>Horse</option>
            <option>Other</option>
          </select>
        </div>
        <button
          type="submit"
          className="btn btn-primary btn-lg btn-block submitButton"
        >
          Add new pet
        </button>
      </form>
    </div>
  );
}

export default App;
