# EMS (Event Management System)
The web-site will manage the times, location and topics or sectors where presenters will meet with investors to present their company to the investor, so that they can invest in them. The meeting will only take place if both the presenter and investor are free at that time slot, share the same topics and the room is free. All reservations are done in conference rooms across different hotels, duration of any meeting is an hour. 

Requirements (6 Web-pages): 

1)      Page that user inserts Hotel information
2)      Page that user inserts investor information
3)      Page that user inserts presenter information
4)      Page that reserves presenter to investor with an allocated time and room
5)      Report
6)      SSIS Package

The web-pages will do the following

1)      The user will add Hotel information, such as hotel name, add conference rooms to the system and for each room a time slot.An example, User can add Hilton with conference room 1 with times 1PM – 2PM, 2PM – 3PM and 3PM - 4PM, Conference room 2 with times 1PM – 2PM, 3PM – 4PM.

2)      Investor Information Page (Name, Mobile, Sectors which he is interested in and the times he wants to meet for that particular sector, The investor should have more than one sector he is interested in, example, Investor X is interested in Finance between 10AM and 1PM and Retail from 4PM – 8PM).

3)      Presenter Information Page (Name, Mobile, Sectors which he is interested in and the times he wants to meet for that particular sector, The presenter should have more than one sector he is interested in, example, presenter X is interested in Finance between 10AM and 1PM and Retail from 4PM – 8PM).

4)      Reservation Page (It will look up the investor then his/her interested sectors, then the time slots for that sector. Afterwards it will match those criteria with an presenter who fits it. Once you have a match the system will allow you to select ONLY available rooms for that time and hotel. Once the reservation is confirmed, the room, investor, and presenter will have status occupied so the system shouldn’t double book them again during those times)

5)      Report (It will contain all the reserved time slot with the investor , presenter, hotel and conference room. Use SRSS for this)

6)      Last thing, SSIS package to populate the hotel table information into the DB. The package will read from several CSV files at a time and then adds it to the table. Each file contains only one line for each hotel information.
