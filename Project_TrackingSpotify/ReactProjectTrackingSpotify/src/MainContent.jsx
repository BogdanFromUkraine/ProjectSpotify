import { Button, ButtonGroup } from '@chakra-ui/react'
import { AuthorizationFunc } from './services/getAuthorizationFunc'
import { useEffect, useState, useRef } from 'react';
import { testFunc } from './services/testFunc'
import styles from './main.module.css'

export default function MainContent({topItems, pointer, setPoiner, setTopItems}) 
{
    const [url, setUrl] = useState();
    const isInitialMount = useRef(true); // Відстеження першого рендерингу
    useEffect(()=>
        {
            if (isInitialMount.current) {
                isInitialMount.current = false; // Встановлюємо в false після першого рендерингу
              } else 
              {
                const auth = async () => 
                    {
                      // setRedirectUrl(await UrlAuthorization(url));
                    }
    
                    auth();
              }
           
        }, [url])
    
    async function handleClick() 
    {
        let url = await AuthorizationFunc(setPoiner);
        setUrl(url);
        
    }

    async function handleClickGetTrack() 
    {
        let notes =  await testFunc();
        await setTopItems(notes);
        console.log(notes);
    }

    
    return <div className="d">
        <div className={styles.main}>
            <div>
                <Button colorScheme='blue' onClick={handleClick}>Authorization</Button>
                <Button onClick={handleClickGetTrack}>Get Top user`s item</Button>
            </div>
            <div className={styles.main_left}>
            {topItems.map((e) => 
                {
                    return <div className={styles.block}>
                        <h2>{e.name}</h2>
                        <h5>Popularity: {e.popularity}</h5>
                    </div>
                })}
            </div>
         
        </div>
    </div>
}