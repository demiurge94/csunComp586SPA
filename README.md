# Metal Genealogy Archive SPA

### This application retrieves data from a database holding my favorite Metal bands as well as Genre descriptions with their genealogy. I used the chart from the age-old documentary Metal: A Headbanger's Journey with some modifications. Since music is very hard to label- especially the genre of Metal I made a few modifications on genre names/types. 
## Hosting
This site is hosted using AWS in an S3 bucket [here](http://demi-client-csun-comp586.s3-website-us-east-1.amazonaws.com/).

## Logging in
The default username is john and the default password is P@ssw0rd. Logging in gives you access to the Genres tab. No authentication is needed to view the lists of artists on the database. 

## The Contents
Using a sql server database hosted using AWS RDS, there are three tables: Genres, Artists, Albums. The Albums table is sparsely populated, while there are at least two artists in the Artists table per genre. Most artists should have a description. 

## Known bugs
Logging in turns the "Login" button to logout, but upon refreshing the page turns back to login, despite the user still being logged in. There is a register component in the angular code that was deleted and re-made. Upon remaking it, it stopped working so that button is commented out in the client code. 

## Comments in the client-side 

Most comments reside to remind me how to perform certain tasks. 

## Interfaces, Services

There are folders in the API side which were created in an attempt to implement more complicated features to be able to perform unit-tests and have more structured code. That attempt was not successful before the deadline of the project but I have left them there to return to it after the semester is over to figure it out. 


