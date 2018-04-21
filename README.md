# smart_zones
prototype for living scenes using smart zones

Disclaimer: This is only a bare bones implementation and it's sole purpose is to test the viability of this approach. Admittedly a lot more features and polish can still be made for this project.

smart_zones is a study to create ambient non player characters, interacting with each other on pre-defined
locations depending on their role. 

Basically whenever a NPC walks into a smart zone, the zone would perform checks if the NPC has a role it needs for it's scene.
If it passes this check, the NPC would then have to perform the role assigned to him until the scene ends. Otherwise the NPC just ignores
the zone and goes about his business.

This project was inspired by an article I've read here http://www.gameaipro.com/
