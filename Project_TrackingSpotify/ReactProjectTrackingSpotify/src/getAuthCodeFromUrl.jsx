export default function GetAuthCodeFromUrl() 
{
    // Отримати поточний URL

    const currentUrl = window.location.href;

    // Створити об'єкт URL
    const url = new URL(currentUrl);

    // Отримати значення параметра 'code'
    const authCode = url.searchParams.get('code');

    return authCode;
}