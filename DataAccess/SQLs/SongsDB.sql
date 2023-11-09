use SongsDB

delete from Songs
delete from Albums

set identity_insert Albums on
insert into Albums (Id, Name) values (1, N'Aacayipsin')
insert into Albums (Id, Name) values (2, N'Dive Deep')
set identity_insert Albums off

set identity_insert Songs on
insert into Songs (Id, Name, Year, Rating, AlbumId) values (1, N'Unutmamalý', 1994, 4.2, 1)
insert into Songs (Id, Name, Year, Rating, AlbumId) values (2, N'Bekle', 1994, 4.5, 1)
insert into Songs (Id, Name, Year, Rating, AlbumId) values (3, N'Enjoy The Ride', 2008, 4.8, 2)
set identity_insert Songs off