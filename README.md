# Prosody

Prosody is our hackathon submission for Hack Princeton Spring 2017

## Inspiration

Finding time in your schedule to be calm can be challenging in today’s connected world. As much as we’d love to make time for meditation, sometimes it’s hard to dedicate those 20 minutes to calm inner silence. Prosody is a gamified version of training your brain. It’s a virtual reality game that teaches the user how to remain calm rewarding the users who stay calm under pressure.

## What it does

Prosody goes through a storyline consisting of three chapters, each getting progressively more intense while still encouraging the user to maintain their calm and collected composure.

It begins with a short calibration period during the prologue before shortly catapulting the user into our storyline.

The game scenario rewards the calmer users with high scores upon finishing each level.

We envision Prosody used in safety training simulations or proactive support for individuals with mental health issues.

## How we built it

Muse headband outputs data in relative values of alpha, beta, gamma, delta, and theta waves. Tracking percentage of beta and gamma waves, associated with stress, we can determine how calm the user is.

3D scenes were built in Unity and with support for the Google Cardboard in mind.

Bluetooth controller to allow the player to navigate the world while the headset is on.

Amazon Polly was used to generate the narration. We used Speech Synthesis Markup Language (SSML) to make the speech more realistic -- adding pauses and emphasis.

[Read more on our DevPost](https://devpost.com/software/prosody)
