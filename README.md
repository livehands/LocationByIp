## Overview 
This is a sample Azure Function that will call an endpoint to get a user's location based on their IP Address.  I created this function as a wrapper as some of the FREE options out there don't have **HTTPS** endpoints and I need a way to make an API call from JavaScript hosted with HTTPS.

## User Location Acquisition 
In many cases you can acquire user's location using the HTML5 Geolocation API, a HTML5 feature, that allows a web page’s visitor to share their location with you **if they so choose** via client side code like JavaScript. The key statement being however, **if they so choose**, the issue is the user has to give us permission to their location. If they don't give permission then our code cannot acquire the user's location and the calls to the Geolocation API services will not provide what we need. 

Secondly, if the user is using an older browser, like say Opera or IE 10, the Geolocation API is not available and you won't be able to acquire the location in this situation either.  

The solution that I provide here is the **_LocationByIP_** endpoint in the function.  

## Application Settings
After deploying this Function you will need to add an Application setting with the name "IPLocationUri" and provide the API URL as the value. 

**EXAMPLE:** 
```
IPLocationUri = https://geolocation-db.com/jsonp
```

## IP Location Services
In my research I found 3 IP Geolocation services that seemed to be the most popular.  You can certainly use your own for this purpose just be aware that you might have to update you client side code to read the values as some APIs return the location as "lat"/"long" and others use "latitude"/"longitude".  I will point this out below in the section on modifying your bot container.

Here are the three APIs I found.  To get a good understanding of how to use this services, read their documentation and modify the LocationViaIP function accordingly.:

1. [GeoLocation DB](http://geolocation-db.com/) Open & seems FREE as no license information is available on the site.  No sign up required.
1. [IP Geolocation API](http://ip-api.com) - Open and Free of non-commercial use. No sign up required. If you exceed the usage limit of 45 requests per minute your access to the API will be temporarily blocked. Repeatedly exceeding the limit will result in your IP address being banned for up to 1 hour. [See the Terms](https://ip-api.com/docs/legal)
1. [IPinfo](https://ipinfo.io) - Account required Free usage of the API is limited to 50,000 API requests per month.

# Usage
  When deployed as coded here will show up a the endpoint **"https://<your-function-name>.azurewebsites.net/api/locationybyip"** it currently only respond to GET requests, but feel free to fork and edit.  
  
  The function returns the object acquired from the API as JSON back to the caller.