#version 330 core
out vec4 color;

in vec3 FragPos;  
in vec3 Normal;  

// Basic items for light worker
uniform vec3 lightPos; 
uniform vec3 viewPos;
uniform vec3 lightColor;
uniform vec3 objectColor;
uniform vec3 ambient;
uniform vec3 diffuse;
uniform vec3 spectr;
uniform int power;
uniform float timer;

void main()
{
    // Animation
    // Shader effect
    // Color change according to the sinusoidal law
    float p1 = 0.5f;
    float p2 = 0.5f;
    vec3 lclr = lightColor * vec3(p1 + p2 * cos(timer), p1 + p2 * cos(3 * timer), p1 + p2 * cos(5 * timer));

    // Ambient
    vec3 ambient = ambient * lclr;
  	
    // Diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diffuse * diff * lclr;
    
    // Specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), power);
    vec3 specular = spectr * spec * lclr;  
        
    vec3 result = (ambient + diffuse + specular) * objectColor;
    color = vec4(result, 1.0f);
	if(dot(norm, lightDir) < 0)
		color = vec4(ambient * objectColor, 1.0f);
} 