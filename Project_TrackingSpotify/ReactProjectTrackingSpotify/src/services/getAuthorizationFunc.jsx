import axios from "axios"

export const  AuthorizationFunc = async (setPoiner) => 
    {
        
        try {
            const result = await axios.get("https://localhost:7150/api/react/Auth");
            window.location.href = result.data.url;
            //змінюю покажчик, щоб виконати операцію 
            setPoiner(true);

            return result.data.url;

        } catch (error) {
            console.error(error);
            
        }
        
    } 
{
    
}