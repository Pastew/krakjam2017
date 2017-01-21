import java.util.ArrayList;
import java.util.Random;

/**
 * Created by Sieciech on 2017-01-20.
 */
public class Town {

    //TODO

    int population;
    double mood;
    double delta;
//====================================================
    int offset;
    double ownMood;
    ArrayList<Influence> influences;

    public void setMood(int krok){

        double temp = this.population/10000*6;
        this.ownMood = 5*Math.sin((krok + this.offset) * (2 * Math.PI / temp));
        double sumOfInfluences = 0;
        for(int i = 0; i<influences.size(); i++){
            double tempInf = influences.get(i).getInfluence(this.mood);
            if(tempInf == 0) influences.remove(i--);
            sumOfInfluences += tempInf;
        }
        this.delta = this.ownMood + sumOfInfluences;
        this.mood += this.delta;
    }

    public Town(int population, double mood){

        this.population = population;
        this.mood = mood;
        this.setMood(0);

        Random r = new Random();
        Double d = new Double(population/10000*6);
        this.offset = r.nextInt(d.intValue());
        this.influences = new ArrayList<Influence>();

    }
}
