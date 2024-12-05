FROM node:23-alpine AS build

WORKDIR /app

COPY package.json package-lock.json ./

COPY . .

RUN npm install

#ARG REACT_APP_BASE_URL
#ENV REACT_APP_BASE_URL=$REACT_APP_BASE_URL
RUN npm run build

FROM nginx:stable-alpine3.20-perl
COPY --from=build /app/build /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]