# Jenkins Sandbox

## The Setup

This is a small sandbox environment that has two small projects with their own sets of unit tests. The idea behind these two projects is that they can interact between each other (sort of).

The Consumer Service (InfinitePing) makes a ping to the Producer Service (WeatherApi). By pinging the service, the consumer should receive a every so often information about the weather that the Producer can provide. This applies if the Consumer is deployed in a production environment, where if it is in Test, it will be just making a ping into nowhere.

Both services have their own sets of very simple unit tests that can be ran to verify if they operate how it is expected they should.

## The Jenkins concept

The idea is to be able to use this simple setup with two utmost basic services and try to deploy them via Jenkins. That's pretty much it. Jenkins should be able to connect to GitHub, get the projects, build them, test, deploy on a VM service that runs Linux. If operationability of the code changes, Jenkins should be able to delete the old project and produce a new build. That's it.

## Notice

The project has a very simple structure for the code, where no `try-catch` conditions are used, as well as there are almost no clauses for dealing with potential errors or absence of connections if one service goes down. The idea was just to experiment with Jenkins having 2 projects operational with their own sets of tests. Configs for pipelines that were used for Jenkins can be found in the `JenkinsBuilds`. 