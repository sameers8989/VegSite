import logo from "./logo.svg";
import "./App.css";
import Login from "./pages/Login";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Vegtable from "./pages/Vegtable";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="vegtable" element={<Vegtable />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
