import axios from "axios"
 

export const  GetArtistById = async (searchValue) => 
    {
        const query = searchValue;
        
        try {
            const result = await axios.get("https://localhost:7150/api/React/Artist", 
            {
                params : {query}
            });
           
            return result.data;

        } catch (error) {
            console.error(error);
            
        }
        
    } 