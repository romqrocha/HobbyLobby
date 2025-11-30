# HobbyLobby
HobbyLobby is a social platform that provides a space for people to express their own interests and find others with the same vision.
<br/><br/>
**Check it out [here](https://hobbylobby-exh7ccedf2cyaaak.westus3-01.azurewebsites.net/)!**

## Some background
This is a personal project turned into a group project, built over the course of about 6 weeks. It's a prototype built by a couple of students on something fun and arguably quite lacking in the online stage. Isn't it great when we meet someone who likes the same niche things as us?

## Features
Next up are the features we added to the project so far. Any features annotated with a `*` are currently locked and only for verified BCIT students (with an active BCIT email address). We hope to change this in the future.

### 1. Selecting and ranking hobbies
HobbyLobby lets users browse and select from a generic dataset of about 500 hobby names. The select hobbies will show up on a user's profile. Then, for extra customization, users can rank their top 3 favorite things to do so that they always show up at the top.

### 2. Finding others based on shared interests
With the search function, anyone can enter the name of a hobby and find all users who say they have it as an interest. The search will yield profile cards of those users sorted by the "Match" percentage - how closely your listed hobbies and theirs are matching.

### 3. Messaging*
If two users are verified students, they can send messages to each other and find out more about their interests. Keep in mind, we have not yet implemented message encryption, so please do not share overly sensitive information! Although we have no reason to ever check them, they will be stored in our database.

### 4. Profile customization
Users can customize their profiles by changing their profile picture, banner, display name, favourite hobbies, and country! Verified students can change their profile picture to any image on the internet, while others can choose from a set of default images.

## Deployment
This is an open source project, after all, so here's how you can deploy it on your own with Azure:
<ol>
  <li>Since you want your own deployment, first fork the project to have full control of the code repository.</li>
  <li>Visit https://portal.azure.com (you'll need to deal with Microsoft for the next steps, sorry).</li>
  <li>Create a new Web App resource and start going through the creation process.</li>
  <li>For "Runtime stack", choose .NET 9.</li>
  <li>For "Operating system", choose Linux.</li>
  <li>Go with either default values or pick them at your own discretion for the rest, and then review and create the resource.</li>
  <li>Pray that Microsoft doesn't give you an obscure error message.</li>
  <li>Once successful, click on the resource and go to "Deployment" -> "Deployment Center" -> "Settings"</li>
  <li>For the deployment source, choose GitHub and select your fork of this repository. You may have to provide authorization for this.</li>
  <li>Adjust the GitHub Action for deployment as necessary (it might think the project in the root folder, instead of in `/BlazorServer`)</li>
  <li><b>Important</b>: click on the resource and go to "Settings" -> "Environment Variables"</li>
  <li><b>You will need to set up a SendGrid account for this</b>: Enter a new environment variable with the key "SendGridKey" and the value being your SendGrid API key. This is required for sending emails, unless you want to replace the email service provider in the code.</li>
  <li>Check if the website given by Azure is up!</li>
</ol>



