import { useEffect, useState } from "react"
import { getUserData } from "./services/getUserData";

export default function UserPage() 
{
    const [userData, setUserData] = useState(null);

    useEffect(()=>
        {
            
            async function foo() 
            {
                const userDat = await getUserData();
                 setUserData(userDat);
            }
            foo();
            console.log(userData);

            const interval = setInterval(() => {
                foo(); // Отримувати дані кожні 5 секунд
                console.log(userData)
              }, 5000);

              return () => clearInterval(interval); 
           
        }, []);

        if (!userData) {
            return <div>No data available</div>;
          }

    return <div className="d">
          
<h1>Name:</h1>
        <h4>{userData.display_name}</h4>
        <h1>Image:</h1>
        <div>
            <img src={userData.images[1].url} />
        </div>
        <h1>Email:</h1>
        <h4>{userData.email}</h4>
        </div>
        
    
}