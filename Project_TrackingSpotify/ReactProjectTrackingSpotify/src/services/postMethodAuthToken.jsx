import axios from 'axios';

export default async function  PostMethodAuthToken(res) 
{
    try {
        const response = await axios.post("https://localhost:7150/api/React/Code", res, 
        {
            headers: 
            {
                "Content-Type": "application/json"
            }
        });
        return response;
        
    } catch (error) {
        console.log(error);
    }
    return null;
}