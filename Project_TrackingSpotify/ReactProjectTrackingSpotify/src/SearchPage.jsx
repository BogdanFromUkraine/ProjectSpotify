import { useEffect, useState } from "react"
import { GetArtistById } from "./services/getArtistById"
import { Input, Button } from '@chakra-ui/react'
import styles from './searchPage.module.css'

export default function SearchPage() 
{
    const [searchValue, setSearchValue] = useState("");
    const [result, setResult] = useState(null);
    
   
        async function handleClick () 
        {
            const result = await GetArtistById(searchValue);
            await setResult(result);

        }
    return <div className="d">
        <div className={styles.content}>
        <div>
            <Input placeholder='Search' size='md' width='auto'  
            value={searchValue}
            onChange={(e) => setSearchValue(e.target.value)} />
            <Button onClick={handleClick}>Find an artist</Button>
        </div>
        {result !== null ? ( <div className={styles.main_data}>
                <div>
                    <img src={result.images[1].url} />
                    <h5>Popularity: { result.popularity  }</h5>
                    <h5>Followers: { result.followers.total }</h5>
                    <h1>{result.name }</h1>
                </div>
        </div>) : (<div>Помилка</div>)}
       
        <div className={styles.hint}>
            <h1>Іd артистів</h1>
        Drake: 3TVXtAsR1Inumwj472S9r4
Ariana Grande: 66CXWjxzNUsdJxJ2JdwvnR
Ed Sheeran: 6eUKZXaKkcviH0Ku9w2n3V
Taylor Swift: 06HL4z0CvFAxyc27GXpf02
Billie Eilish: 6qqNVTkY8uBg9cP3Jd7DAH
        </div>
        </div>
       
    </div>
}