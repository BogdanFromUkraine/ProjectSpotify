import { BrowserRouter as Router, Route,  Link, Routes } from 'react-router-dom';
import MainContent from './MainContent';
import SearchPage from './SearchPage';

export default function SideBar() 
{
    return <nav className="nav flex-column" >
   
    <Link className="nav-link active" to="/">Home</Link>
    
    <Link className="nav-link active" to="/search">Search</Link>

    <Link className="nav-link active" to="/playlist">Playlist</Link>
    
    <Link className="nav-link active" to="/user">User</Link>
  </nav>

}