using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVDualSummative
{
    class ShowTime
    {
        private static void Main(string[] args)
        {
            //array of planet objects
            var planets = new[]
            {
                //name, population, max population (9 digits because int variable), x coord, y coord
                new Planet("55Canrie", 548254, 132568743, 678, 56),
                new Planet("GJ 1214b", 654223, 982756438, 567, 567),
                new Planet("Osiris", 654265, 564237894, 56, 5678),
                new Planet("Methuselah", 789073, 432789540, 567, 67),
                new Planet("Kepler-1B", 454356, 432179430, 657, 567)
            };
            
            //array of route objects    
            var routes = new[]
            {
                //starting planet and destination planet routes with speed
                new Route(planets[0], planets[1], 3),
                new Route(planets[0], planets[2], 3),
                new Route(planets[0], planets[3], 3),
                new Route(planets[0], planets[4], 3)
            };
            //Route, passengers, max passengers, speed
            Spaceship Tartarus = new Spaceship(routes[0], 175, 650, 3);

            Console.WriteLine(planets[0].ToString() + "\n" + planets[1].ToString() + routes[0].ToString() + planets[2].ToString() + routes[1].ToString() + planets[3].ToString() + routes[2].ToString() + planets[4].ToString() + routes[3].ToString() + Tartarus.ToString());

            //To get the best route, make a ratio for distance and population for each planet
            float[] ratio =
            {
                (routes[0].distance / planets[1].population),
                (routes[1].distance / planets[2].population),
                (routes[2].distance / planets[3].population),
                (routes[3].distance / planets[4].population)
            };

            //All these while loops ensure there are no -ve people left stranded
            int shipSent = 0;
            while (planets[1].population > 0)
            {
                //Make a new spaceship object, but with the exct same parameters
                
                //If the planet's population is higher than the max passenger limit, decrease the population by max limit
                if (planets[1].population > Tartarus.maxPassengers)
                {
                    planets[1].population -= Tartarus.maxPassengers;
                }
                //If it is lower, set the passenger limit to the current population, and decrease it from there.
                else
                {
                    Tartarus.passengers = planets[1].population;
                    planets[1].population -= Tartarus.passengers;
                }
                shipSent++;

            }
            Console.WriteLine("The ship needs to go to GJ1214b " + shipSent + " times to save everyone");

            while (planets[2].population > 0)
            {
                if (planets[2].population > Tartarus.maxPassengers)
                {
                    planets[2].population -= Tartarus.maxPassengers;
                }
                else
                {
                    Tartarus.passengers = planets[2].population;
                    planets[2].population -= Tartarus.passengers;
                }

                shipSent++;
            }
            Console.WriteLine("The ship needs to go to Osiris " + shipSent + " times to save everyone");

            while (planets[3].population > 0)
            {
                if (planets[3].population > Tartarus.maxPassengers)
                {
                    planets[3].population -= Tartarus.maxPassengers;
                }
                else
                {
                    Tartarus.passengers = planets[3].population;
                    planets[3].population -= Tartarus.passengers;
                }

                shipSent++;
            }
            Console.WriteLine("The ship needs to go to Methuselah " + shipSent + " times to save everyone");

            while (planets[4].population > 0)
            {

                if (planets[4].population > Tartarus.maxPassengers)
                {
                    planets[4].population -= Tartarus.maxPassengers;
                }
                else
                {
                    Tartarus.passengers = planets[4].population;
                    planets[4].population -= Tartarus.passengers;
                }

                shipSent++;
            }
            Console.WriteLine("The ship needs to go to Kepler1B " + shipSent + " times to save everyone");
            Console.WriteLine(" ");

            //Print out the list for the calculated ratios
            Console.WriteLine("The ratios for distance vs population for each planet and route are: " + ratio[0] + ", " + ratio[1] + ", " + ratio[2] + ", " + ratio[3]);

            //Sort the array's together so they are related to each other
            //Routes array sorted when the ratio array gets sorted
            Array.Sort(ratio, routes);
            Console.WriteLine("The best route for evacuation based on the lowest ratio is " + ratio[0] + "\n" + routes[0]);
        }
    }


    class Planet
    {
       //Initializing attributes as getters and setters
        public string name { get; set; }
        public int population { get; set; }
        public int maxPopulation { get; set; }
        public float x { get; set; }
        public float y { get; set; }

        //Planet constructor
        public Planet(string pName, int pPopu, int pMaxPopu, int pX, int pY)
        {
            this.name = pName;
            this.population = pPopu;
            this.maxPopulation = pMaxPopu;
            this.x = pX;
            this.y = pY;
        }

        //Printing the information
        override
        public string ToString()
        {
            return "Planet name is: " + name + "\nPopulation is: " + population + "\nMax population is: " + maxPopulation + "\nLocated at: " + (x + "," + y) + "\n";
        }
    }
    class Spaceship
    {
        //Initializing attributes as getters and setters
        public Route route { get; set; }
        public int passengers { get; set; }
        public int maxPassengers { get; set; }
        public float speed { get; set; }

        //Spaceship constructor
        public Spaceship(Route sRoute, int sPassen, int sMaxPassen, float sSpeed)
        {
            this.route = sRoute;
            this.passengers = sPassen;
            this.maxPassengers = sMaxPassen;
            this.speed = sSpeed;
        }
        //Printing the information
        override
        public string ToString()
        {
            return "Spaceship has " + passengers + " many people on board" + "\nCan hold: " + maxPassengers + " people total" + "\nTravelling at a speed of: " + speed + " light years" + "\n";
        }

    }
    class Route
    {
        //Initializing attributes as getters and setters
        public Planet StartingPlanet { get; set; }
        public Planet DestinationPlanet { get; set; }
        public float distance { get; set; }
        public float time { get; set; }
        public float speed { get; set; }

        //Route constructor
        public Route(Planet rStart, Planet rDestin, float rspeed)
        {
            this.StartingPlanet = rStart;
            this.DestinationPlanet = rDestin;
            this.speed = rspeed;
            distance = CalculateDistance(StartingPlanet.x - DestinationPlanet.x, StartingPlanet.y - DestinationPlanet.y);
            time = distance / speed;
        }

        //Using a cartesian plane to calculate the distance.
        float CalculateDistance(float x, float y)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);

            //Calculating the distance between two points using pythagoras theorem
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            return (float)distance;
        }

        override
        public string ToString()
        {
            return "This route is from " + StartingPlanet.name + " to " + DestinationPlanet.name + "\nDistance between them is: " + distance + " AU" + "\nIt will take " + time + " light years to get there" + "\n\n";
        }
    }
}