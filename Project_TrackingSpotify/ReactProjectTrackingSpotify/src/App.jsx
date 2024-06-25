import MainContent from './MainContent'
import SideBar from './SideBar'
import "./App.css"
import { useEffect, useState, useRef } from 'react'
import GetAuthCodeFromUrl from './getAuthCodeFromUrl'
import PostMethodAuthToken from './services/postMethodAuthToken'
import { Route, Routes } from 'react-router-dom'
import SearchPage from './SearchPage'
import PlaylistPage from './PlaylistPage'
import UserPage from './UserPage'



function App() {
  const [topItems, setTopItems] = useState([]);
  const [pointer, setPointer] = useState(false);
  const isInitialMount = useRef(true); // Відстеження першого рендерингу
  
  
 //хук для отримання authCode з url та post запит до беку
 useEffect(() => 
  {
    
    if (false) {
      isInitialMount.current = false; // Встановлюємо в false після першого рендерингу
    } else 
    {
      const res = GetAuthCodeFromUrl();

      console.log(res);
      
      PostMethodAuthToken(res);
    }

  }, [pointer]);

 //хук для отримання даних з бекенду
  // useEffect( () => 
  //   {
  //       const fetchData =  async () => 
  //         {
  //          let notes =  await testFunc();
  //          await setTopItems(notes);
           
  //         }

  //           fetchData();
  //   }, [])

    useEffect(() => {

    }, [topItems]); // Цей useEffect буде виконуватись щоразу, коли topItems зміниться
  

  return (
    <div className="mainPart">
    <SideBar/>
    <Routes>
      <Route path="/" element={<MainContent topItems={topItems} pointer={pointer} setPointer={setPointer} setTopItems={setTopItems}/>} />
      <Route path="/search" element={<SearchPage/>} />
      <Route path="/playlist" element={<PlaylistPage/>} />
      <Route path="/user" element={<UserPage/>} />
    </Routes>



    
    </div>
  )
}

export default App
