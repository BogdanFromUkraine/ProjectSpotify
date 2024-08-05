import axios from "axios"
 

export const  getUserData = async () => 
{
    
    try {
        const result = await axios.get("https://localhost:7150/api/react/User");
        return result.data;
    } catch (error) {
        console.error(error);
        
    }
    
}