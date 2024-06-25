import axios from "axios"
 

export const  testFunc = async () => 
{
    
    try {
        const result = await axios.get("https://localhost:7150/api/react");        
        return result.data;
    } catch (error) {
        console.error(error);
        
    }
    
}