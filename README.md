# UrlShortener

This is a tool for shortening URLs. Here are some tips and comments:
- To run the application, you need to set some mandatory values in appsettings.
- The solution uses a in-memory simulation of DB, this would be swapped for a proper implementation in the production environment (ideally BigData NoSQL)
- On several occasions there are classes with asynchronous notation, but lack asynchronous calls. This is to provide an asynchronous interface, which would ideally use a different, asynchronous implementation. 
- The solution contains Unit Test project, but the test coverage is very limited due to time constraints. This would be higher under normal circumstances
