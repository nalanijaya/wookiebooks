# Wookie Books REST API

Wookie books REST API was implemented using .net core 2.2 and Visual Studio 2017. This enables swagger and postman testing.

1. For POSTMAN end point testing, export Wookie Books.postman_collection.json file located in WookieBooks.API folder.

![image](https://user-images.githubusercontent.com/13043726/115060629-baa59a00-9f05-11eb-90e8-0f9a12596d2b.png)

![image](https://user-images.githubusercontent.com/13043726/115060715-d446e180-9f05-11eb-9917-d99b7eee1584.png)


2. For swagger testing, use home page.

![image](https://user-images.githubusercontent.com/13043726/115060666-c3966b80-9f05-11eb-8caa-bebbb11f9dc9.png)

# Note
I had the following error in my docker build at the time I was sending the repo link.

![image](https://user-images.githubusercontent.com/13043726/115061036-3ef81d00-9f06-11eb-92bf-b0707384436d.png)

I was able to fix it using added docker-compose.yml file. Now the project can run on docker as well.
I have pushed the image to docker hub.

Commands:
docker pull nalani2020/wookie-books:wookiebooks.api.1.0
docker run -d -p 49460:80 --name wookiebooks nalani2020/wookie-books:wookiebooks.api.1.0


# References
1. https://timdeschryver.dev/blog/how-to-test-your-csharp-web-api
2. https://learning.postman.com/docs/writing-scripts/test-scripts/
3. https://thegreenerman.medium.com/set-up-https-on-local-with-net-core-and-docker-7a41f030fc76
4. https://github.com/microsoft/artifacts-credprovider/issues/63
5. https://www.reddit.com/r/docker/comments/krikxx/docker_pull_results_in_httpsregistry1dockeriov2/giabgzq/
6. https://developers.google.com/speed/public-dns/docs/using
7. https://softchris.github.io/pages/dotnet-dockerize.html#build-our-image-start-container
