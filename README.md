#SPORTLIZE
==========
Il progetto va a creare tre microservizi che possono essere utilizzati per supportare un app Social, questo progetto è disponibile al seguente repository reso pubblico per la consegna del progetto: 
https://github.com/NathanMNZ02?tab=repositories

La struttura del progetto è la seguente:
- SportLizeFrontRazor, rappresenterà l'interfaccia del social, in essa si andranno a chiamare le API per implementare le funzioni necessarie.

- SportLizeProfileApi, main service che conterrà tutte le principali informazioni sull'account dell'utente tra cui follower, following, post e commenti sotto essi.

- SportLizeTalk, servizio che implementa le funzionalità di messaggistica (una sorta di direct di Instagram) in questo caso avremo delle chiamate Http per ottenere gli utenti che scambiano tra loro messaggi, implementato tramite chiamate Http siccome tipicamente gli utenti di un Social possono essere milioni, perciò delle semplici chiamate senza il relativo salvataggio degli utenti è meno dispendioso.

- SportLizeTeam, servizio che implementa la funzionalità di gruppi, ovvero dei gruppi di utenti si potranno scambiare messaggi e discutere su questioni (sportive), in questo caso la comunicazione avverrà tramite Kafka quindi vi sarà il relativo salvataggio degli utenti all'interno del db UserKafka, più dispendioso in termini di storage.

I database sono implementati tramite le migrations, per cui al primo lancio dell'applicativo essi verranno costruiti all'interno del container sql server.

Github credential for github packages
Username: NathanMNZ02
Password: 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