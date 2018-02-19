/*
 How would you go about testing a distributed system such as Gmail, before releasing it to the public. How would you simulate realistic server load? 
 */
/*
1. Write multi threaded code which simulates emails from multiple hosts.
2. Simulate other factors like new users joining/ adminstrative tasks/emails/spams.
3. Since he talks about distribution, Test node failures.
4. Test replication of storage.
5. Test storage of attachments.
6. Test across data centres.
7. Test with timezones. Various timezones have various loads at different times.
8. Test dispatch of advertisements. 
 */